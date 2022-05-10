namespace SDK.Enum
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum ActionType : byte
    {
        NoAction,
        Create,
        Update,
        Delete
    }
}
