﻿using Codebreak.Framework.Database;
using Codebreak.WorldService.World.Database.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.WorldService.World.Database.Repository
{
    public sealed class SuperAreaRepository : Repository<SuperAreaRepository, SuperAreaDAO>
    {
        private Dictionary<int, SuperAreaDAO> _superAreaById;

        public SuperAreaRepository()
        {
            _superAreaById = new Dictionary<int, SuperAreaDAO>();
        }

        public override void OnObjectAdded(SuperAreaDAO superArea)
        {
            _superAreaById.Add(superArea.Id, superArea);
        }

        public override void OnObjectRemoved(SuperAreaDAO superArea)
        {
        }
    }

    public sealed class AreaRepository : Repository<AreaRepository, AreaDAO>
    {
        private Dictionary<int, AreaDAO> _areaById;

        public AreaRepository()
        {
            _areaById = new Dictionary<int, AreaDAO>();
        }

        public override void OnObjectAdded(AreaDAO area)
        {
            _areaById.Add(area.Id, area);
        }

        public override void OnObjectRemoved(AreaDAO area)
        {
        }
    }

    public sealed class SubAreaRepository : Repository<SubAreaRepository, SubAreaDAO>
    {
        private Dictionary<int, SubAreaDAO> _subAreaById;

        public SubAreaRepository()
        {
            _subAreaById = new Dictionary<int, SubAreaDAO>();
        }

        public override void OnObjectAdded(SubAreaDAO subArea)
        {
        }

        public override void OnObjectRemoved(SubAreaDAO subArea)
        {
        }
    }
}
