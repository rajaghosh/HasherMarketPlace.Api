using HasherMarketPlace.ModelHelper.Models;

namespace HasherMarketPlace.BusinessService.LoggerFactory
{
    public interface ICustomLoggerFactory
    {
        ILoggerObjContract CreateLogger(LoggerType type);
    }
}
