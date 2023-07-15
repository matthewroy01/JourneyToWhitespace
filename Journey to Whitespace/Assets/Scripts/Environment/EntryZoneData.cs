using UnityEngine;

namespace Environment
{
    [CreateAssetMenu(fileName = "New Entry Zone Data", menuName = "Whitespace/Entry Zone Data", order = 1)]
    public class EntryZoneData : ScriptableObject
    {
        public string Name => _name;
        public string Affiliation => _affiliation;
        public string Sector => _sector;
        
        [SerializeField] private string _name;
        [SerializeField] private string _affiliation;
        [SerializeField] private string _sector;
        
        // TODO: add data for which scene/level to load
    }
}
