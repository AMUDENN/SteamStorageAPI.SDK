namespace SteamStorageAPI.SDK.Utilities.ApiControllers;

[AttributeUsage(AttributeTargets.Field)]
internal sealed class ApiControllerAttribute : Attribute
{
    public ApiControllerAttribute(ApiConstants.ApiControllers controller)
    {
        Controller = controller;
    }

    public ApiConstants.ApiControllers Controller { get; }
}