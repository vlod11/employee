using Requests.Attributes;

namespace Requests
{
    public class PositionAddRequest
    {
        [RequiredNotEmpty]
        public string Title { get; set; }
    }
}