namespace Food.Application.Wrapper
{
	public class ApiResponse<T>
	{
        public ApiResponse()
        {
            
        }
        //success response.
        public ApiResponse(T data,string message = null)
		{
			Successed = true;
			Message = message;
			Data = data;
		}
		//failed response
		public ApiResponse(string message)
		{
			Successed = false;
			Message = message;
		}
		public bool Successed { get; set; }
		public string Message { get; set; }
		public List<string> Error { get; set; }
        public T Data { get; set; }
		 
	}
}
