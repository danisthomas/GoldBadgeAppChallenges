using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Repository
{

    public class BadgesRepository
    {
        public Badges badge = new Badges();
        public Dictionary<int, Badges> _badgeDict = new Dictionary<int, Badges>();
        public List<string> _listofDoors = new List<string>();

        public List<Badges> _listofBadges = new List<Badges>();

        //Create

        public void CreateNewBadge(Badges badges)
        {
            _badgeDict.Add(badges.BadgeID, badges);
            _listofBadges.Add(badge);
        }


        //Read

        public Dictionary<int, Badges> GetDictOfBadges()
        {
            return _badgeDict;
        }

        public List<Badges> GetListofBadges()
        {
            return _listofBadges;
        }

        public List<string> GetListOfDoors()
        {
            return _listofDoors;
        }

        //Delete

        public bool DeleteDoorsOfCurrentListOfBadges(int badgeID)
        {
            // Badges badge = GetBadgeByBadgeID();

            if (badge.BadgeID != badgeID)
            {
                return false;
            }
            int initialCount = _badgeDict.Count;

            _badgeDict.Remove(badge.BadgeID);

            if (initialCount > _badgeDict.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper

        public Badges GetBadgeByBadgeID(int ID)
        {

            foreach (KeyValuePair<int, Badges> badges in _badgeDict)
            {
                if (_badgeDict.TryGetValue(ID, out badge ))
                {
                    return badge;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
