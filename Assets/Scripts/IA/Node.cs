using System.Collections.Generic;
using System.Linq;

namespace BehaviorTrees{
    public class UntilFail : Node {
        public UntilFail(string name) : base(name) { }

        public override Status Process()
        {
            if(children[0].Process() == Status.Failure){
                Reset();
                return Status.Failure;
            }

            return Status.Running;
        }
    }
    public class Inverter: Node{
        public Inverter(string name) : base(name) { }

        public override Status Process()
        {
            switch(children[0].Process()){
                case Status.Running:
                    return Status.Running;
                case Status.Failure:
                    return Status.Success;
                default:
                    return Status.Failure;
            }
        }
    }
    public class RandomSelector : PrioritySelector{
        public override List<Node> SortChildren() => children.Shuffle().ToList();

        public RandomSelector(string name) : base(name) { }
    }
    public class PrioritySelector : Selector {
        List<Node> sortedChildren;
        List<Node> SortedChildren => sortedChildren ??= SortChildren();

        public virtual List<Node> SortChildren() => children.OrderByDescending(child => child.priority).ToList();

        public PrioritySelector(string name) : base(name) { }

            public override void Reset()
            {
                base.Reset();
                sortedChildren = null;
            }

            public override Status Process()
            {
                foreach(var child in SortedChildren){
                    switch(child.Process()){
                        case Status.Running:
                            return Status.Running;
                        case Status.Success:
                            return Status.Success;
                        default:
                            continue;
                    }
                }

                return Status.Failure;
            }
    }
    public class Selector : Node{
        public Selector(string name, int priority = 0) : base(name, priority) { }

        public override Status Process()
        {
            if(currentChild < children.Count){
                switch(children[currentChild].Process()){
                    case Status.Running:
                    //UnityEngine.Debug.Log("RepiteRUnning");
                        return Status.Running;
                    case Status.Success:
                        Reset();
                        //UnityEngine.Debug.Log("Reset y succes");
                        return Status.Success;
                    default:
                    //UnityEngine.Debug.Log("Failure");
                    //UnityEngine.Debug.Log("CUrretn:"+currentChild);
                        currentChild++;
                        return Status.Running;
                }
            }
            //UnityEngine.Debug.Log(children.Count);
            //UnityEngine.Debug.Log("current: "+currentChild);
            Reset();
            return Status.Failure;
        }
    }
    public class Sequence : Node {
        public Sequence(string name, int priority = 0) : base(name, priority){ }

        public override Status Process()
        {
            if(currentChild < children.Count){
                switch(children[currentChild].Process()){
                    case Status.Running:
                        return Status.Running;
                    case Status.Failure:
                        Repeat();
                        return Status.Failure;
                    default:
                        currentChild++;
                        return currentChild == children.Count ? Status.Success : Status.Running;
                }
            }

            Repeat();
            return Status.Success;
        }   
    }
    public class Leaf : Node {
        readonly EnemyInterfae moveCube;

        public Leaf(string name, EnemyInterfae moveCube, int priority = 0) : base(name, priority){
            this.moveCube = moveCube;
        }

        public override Status Process() => moveCube.Process();
        public override void Reset() => moveCube.Reset();
        public override void Repeat() => moveCube.Repeat();
    }

    public class Node
    {
        public enum Status{ Success, Failure, Running}

        public readonly string name;
        public readonly int priority;

        public readonly List<Node> children = new();
        protected int currentChild;

        public Node(string name = "Node", int priority = 0){
            this.name = name;
            this.priority = priority;
        }

        public void AddChild(Node child) => children.Add(child);

        public virtual Status Process() => children[currentChild].Process();

        public virtual void Reset(){
            currentChild = 0;
            foreach(var child in children){
                child.Reset();
            }
        }

        public virtual void Repeat(){
                children[0].Process();
        }
    }
    public class BehaviorTree : Node {

        public BehaviorTree(string name) : base(name) { }

        public override Status Process()
        {
            while (currentChild < children.Count){
                var status = children[currentChild].Process();
                /*if (status != Status.Success){
                    return status;
                }
                if(currentChild > children.Count){
                    currentChild = 0;
                currentChild++;
                }*/
                return status;
            }
            return Status.Success;
        }
    }
    
}
