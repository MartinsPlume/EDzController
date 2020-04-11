namespace EDzController.Controllers.V1.Resources
{
    public class AccessTokenResource
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long Expiration { get; set; }
    }
}