namespace API.Requests;

public class CreateChatRequest
{
    public string FirstUserId { get; set; }
    public string SecondUserId { get; set; }
    public string ChatName { get; set; }
}