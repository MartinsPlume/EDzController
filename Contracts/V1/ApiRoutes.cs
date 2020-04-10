namespace EDzController.Contracts.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";

        private const string Version = "v1";

        private const string Base = Root + "/" + Version;

        public static class Tests
        {
            public const string GetAll = Base + "/tests";
            public const string Get = Base + "/tests/{testId}";
            public const string Create = Base + "/tests";
        }
    }
}
