using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Contract.V3.Aos
{
    public class MemberContract
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
