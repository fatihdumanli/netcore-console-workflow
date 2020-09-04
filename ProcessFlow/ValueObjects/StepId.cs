using System;

namespace ProcessFlow.ValueObjects
{
    public class StepId
    {
        private Guid _id;

        private StepId(Guid id)
        {
            _id = id;
        }

        public static StepId Generate()
        {
            return new StepId(Guid.NewGuid());
        }

        public override string ToString()
        {
            return _id.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            if(obj is StepId)
            {
                return (obj as StepId)._id == this._id;
            }

            return false;
        }
    }
}