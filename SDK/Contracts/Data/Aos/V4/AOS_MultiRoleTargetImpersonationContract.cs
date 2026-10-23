
namespace SDK.Contracts.Data.Aos.V4
{
    /// <summary>
    /// <b>Optional.</b>  
    /// Allows to specify the <b>Node</b> and <b>WorkRole</b> to complete the operation as. If <i>NodeId</i> and <i>WorkRoleId</i> is not specified, the operation
    /// is completed as the <b>Node</b> and <b>WorkRole</b> that owns the <b>Order</b>.  
    /// If <i>Login</i> is specified, the operation is completed as the <b>Account</b> identified by the <i>Login</i>. If it is not specified, the operation is completed as the Account
    /// identified by <c>Token header</c> if <b>Myself</b> is true, otherwise it is completed as the Account that owns the <b>Order</b>.
    /// </summary>
    public class AOS_MultiRoleTargetImpersonationContract
    {
        public int? NodeId { get; set; }

        public int? WorkRoleId { get; set; }

        public string Login { get; set; }

        public bool Myself { get; set; }
    }
}
