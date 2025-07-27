using DomainDrivenDesign_Poc.Shared.Result;

namespace DomainDrivenDesign_Poc.Business.ApplicationService.StudentHandler.Base;

public abstract class BaseHandler
{
    protected CommandResult CreateErrorsCommand(Dictionary<string, string> errors)
    {
        var firstMessage = errors.First();

        return new CommandResult(false, $"{firstMessage.Value}");
    }
}