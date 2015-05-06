namespace ProjectEuler.Framework {
    public interface IProblem {
        string Name { get; }
        int Id { get; }
        void Run();
    }
}