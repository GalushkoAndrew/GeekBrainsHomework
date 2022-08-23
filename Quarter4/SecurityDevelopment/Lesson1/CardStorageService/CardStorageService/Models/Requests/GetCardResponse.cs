namespace CardStorageService.Models.Requests
{
    public class GetCardResponse : IOperationResult
    {
        public CardDto Card { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
