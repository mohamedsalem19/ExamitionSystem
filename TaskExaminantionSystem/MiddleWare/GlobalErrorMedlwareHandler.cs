namespace TaskExaminantionSystem.MiddleWare
{
    public class GlobalErrorMedlwareHandler
    {
        RequestDelegate _moveNext;
        public GlobalErrorMedlwareHandler(RequestDelegate moveNext)
        {
            _moveNext = moveNext;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _moveNext(context);
            }
            catch (Exception ex)
            {

                File.WriteAllText("D:\\Logs.Txt", $"Error Ocuerd {ex.Message}");
            }
        }
    }
}
