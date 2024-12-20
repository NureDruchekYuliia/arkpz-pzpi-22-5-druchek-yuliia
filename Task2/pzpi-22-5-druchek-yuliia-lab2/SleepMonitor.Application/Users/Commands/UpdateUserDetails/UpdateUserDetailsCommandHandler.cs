using MediatR;
using Microsoft.AspNetCore.Identity;
using SleepMonitor.Domain.Entities;
using SleepMonitor.Domain.Exceptions;

namespace SleepMonitor.Application.Users.Commands.UpdateUserDetails;

internal class UpdateUserDetailsCommandHandler(IUserContext userContext,
    IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
{
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(User), user!.Id);

        dbUser.DateOfBirth = request.DateOfBirth;
        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}
