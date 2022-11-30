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

        protected GameEntity(Space space)
        {
            this._space = space;    
        }

        protected virtual void Die() { }

    }
}
