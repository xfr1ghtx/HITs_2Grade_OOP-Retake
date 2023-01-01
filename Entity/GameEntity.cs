using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxy.Entity
{
    public abstract class GameEntity
    {
        public Coordinate coordinate;
        protected Space _space;
        public bool IsExist { get; protected set; }

        protected GameEntity(Space space)
        {
            this._space = space;
            this.IsExist= true;
        }

        protected virtual void Die() { 
            IsExist = false;
        }

    }
}
