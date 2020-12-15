using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public class ClaimsRepository
    {
        
        private Claims newClaim = new Claims();
        private Queue<Claims> claimsQueue = new Queue<Claims>();
        private List<Claims> _listOfClaims = new List<Claims>();

        //Create

        public void AddClaimsToList(Claims content)
        {
            _listOfClaims.Add(content);
            claimsQueue.Enqueue(content) ;          
        }

        //Read
 
        public List<Claims> GetListOfClaims() 
        {
           return _listOfClaims;            
        }

        public Queue<Claims> GetQueueOfClaims()
        {
            return claimsQueue;
        }

        //Delete

        public void  DeleteClaimFromList()
        {
           Claims peekClaim = claimsQueue.Peek();
           //List<Claims> = GetListOfClaims(claim);
            _listOfClaims.Remove(peekClaim);
        }
        //helper
        public void FirstClaimInQueue()
        {
            claimsQueue.Peek();
        }
    }
}
