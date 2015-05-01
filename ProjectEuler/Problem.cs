using System;

namespace ProjectEuler {

    public interface Problem {

        string Name { get; }
        int Id { get; }

        void Run();
    }

}