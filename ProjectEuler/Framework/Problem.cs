using System;

namespace ProjectEuler.Framework {

    public interface Problem {

        string Name { get; }
        int Id { get; }

        void Run();
    }

}