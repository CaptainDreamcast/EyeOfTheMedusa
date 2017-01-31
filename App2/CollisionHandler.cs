using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public static class CollisionHandler
    {
        public static List<int[]> HandleShots(List<Shot> shots, List<CollisionObject> collisionObjects){
            List<int[]> returnList;
            returnList = new List<int[]>();
            int[] integertuple;

            
            foreach (Shot shot in shots)
            {
                foreach (CollisionObject collisionObject in collisionObjects)
                {
                    if (checkSingleShotWithObject(shot, collisionObject)) {
                        integertuple = new int[2];
                        integertuple[0] = collisionObjects.IndexOf(collisionObject);
                        integertuple[1] = shots.IndexOf(shot);
                        returnList.Add(integertuple);
                        break;
                    }
                }

            }

            return returnList;
        }

        private static bool checkSingleShotWithObject(Shot shot, CollisionObject collisionObject)
        {
            return (
                (
                (shot.PositionX > collisionObject.PositionX && shot.PositionX < collisionObject.PositionX + collisionObject.SizeX) ||
                (shot.PositionX + shot.SizeX > collisionObject.PositionX && shot.PositionX + shot.SizeX < collisionObject.PositionX + collisionObject.SizeX)
                ) && (
                (shot.PositionY > collisionObject.PositionY && shot.PositionY < collisionObject.PositionY + collisionObject.SizeY) ||
                (shot.PositionY + shot.SizeY > collisionObject.PositionY && shot.PositionY + shot.SizeY < collisionObject.PositionY + collisionObject.SizeY)
                )


                ) ;
        }
    }
}
