using System;
using System.Collections.Generic;
using System.Linq;

namespace NiceFSM.Entities
{
	public class FSMEntityManager {
		List<IFSMEntity> entities = new List<IFSMEntity>();
		
		public static FSMEntityManager Instance {
			get { 
				if (instance == null)
					instance = new FSMEntityManager();
				return instance;
			}
		}
		static FSMEntityManager instance;
	
		FSMEntityManager () {}
	
		public void RegisterEntity(IFSMEntity entity) {
			entities.Add(entity);
		}
	
		public void RemoveAll() {
			entities.Clear();
		}
	
		public List<IFSMEntity> GetEntities() {
			return entities;
		}
	
		public IFSMEntity GetEntityById(int id) {
			return entities.FirstOrDefault(e => e.Id == id);
		}
	}
}
