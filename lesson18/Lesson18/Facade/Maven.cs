using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    //this is the facade
    //it interacts with all subsystems and eases client interaction
    public class Maven
    {
        BuildValidator _buildValidator;
        Compiler _compiler;
        DependencyLoader _dependencyLoader;
        PackageHandler _packageHandler;
        TestHandler _testHandler;

        public Maven(BuildValidator buildValidator, Compiler compiler, 
            DependencyLoader dependencyLoader,  PackageHandler packageHandler, TestHandler testHandler)
        {
            _buildValidator = buildValidator;
            _compiler = compiler;
            _dependencyLoader = dependencyLoader;
            _packageHandler = packageHandler;
            _testHandler = testHandler;
        }

        public void Build()
        {
            _buildValidator.Validate();
            _compiler.Compile();
            _testHandler.RunTests();
            _dependencyLoader.LoadDependencies();
            _packageHandler.CreatePackage();
        }
    }
}
