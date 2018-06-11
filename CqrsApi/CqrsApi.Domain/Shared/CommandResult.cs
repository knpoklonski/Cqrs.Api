namespace CqrsApi.Domain.Shared
{
    public class CommandResult
    {
        private CommandResult() { }

        private CommandResult(string failureReason)
        {
            FailureReason = failureReason;
        }

        public string FailureReason { get; }

        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);

        public static CommandResult Success()
        {
            return new CommandResult();
        }

        public static CommandResult Fail(string reason)
        {
            return new CommandResult(reason);
        }
    }

    public class CommandResult<TAggregateResult>
    {
        private CommandResult()
        {
        }

        private CommandResult(TAggregateResult result, string failureReason = null) {
            Result = result;
            FailureReason = failureReason;
        }

        public string FailureReason { get; }

        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);

        public TAggregateResult Result { get; }

        public static CommandResult<TAggregateResult> Success(TAggregateResult result)
        {
            return new CommandResult<TAggregateResult>(result, null);
        }

        public static CommandResult<TAggregateResult> Fail(string reason)
        {
            return new CommandResult<TAggregateResult>(default(TAggregateResult), reason);
        }
    }
}
