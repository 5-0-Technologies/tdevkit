namespace Core.Contract.V3.Aos
{
    public class OrderInfoContract
    {
        public OrderContract Order { get; set; }

        public long Created { get; set; }

        public bool IsOwner { get; set; }

        public bool IsTarget { get; set; }

        public MemberContract Creator { get; set; }

        public MemberContract Sender { get; set; }

        public bool CanDiscard { get; set; }
    }
}
