using ArraysAndStrings;

namespace Tests;

public class DynamicProgrammingServiceTests
{
    private readonly IDynamicProgrammingService _dynamicProgrammingService;

    public DynamicProgrammingServiceTests()
    {
        _dynamicProgrammingService = new DynamicProgrammingService();
    }
}