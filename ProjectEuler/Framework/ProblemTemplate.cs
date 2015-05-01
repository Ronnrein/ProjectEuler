using $safeprojectname$.Framework;

namespace $safeprojectname$.Problems {
    public class $itemname$ : Problem{
        public string Name {
            get { return "Name of problem"; }
        }

        public int Id {
            get { return 0; }
        }

        public void Run() {
            throw new System.NotImplementedException();
        }
    }
}