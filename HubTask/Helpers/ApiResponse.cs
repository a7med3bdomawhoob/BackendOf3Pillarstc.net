namespace HubTask.Helpers
{
    public class ApiResponse
    {
        public string message { get; set; }
        public int status { get; set; }
        public ApiResponse(int status, string message = null)
        {
            this.message = message ?? viewerror(status); //if null colease operator
            this.status = status;
        }
        private string viewerror(int status)
        => status switch
        {
            400 => "bad request ",
            404 => "not found ",
            500 => "server error ",
            401 => "Authorized ",
            _ => null
        };
    }
}
