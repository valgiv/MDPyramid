using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPyramid
{
    public class ProcessData
    {
        //pyramid
        private List<List<int>> lst;
        private List<List<Step>> stepsLst;

        public StepsRoutes FindMax(List<List<int>> pyramid)
        {
            lst = pyramid;
            stepsLst = new List<List<Step>>();

            var currentRoute = new List<Step>();
            currentRoute.Add(
                new Step()
                {
                    StepLine = 0,
                    StepCol = 0,
                    Value = lst[0][0]
                });

            FindRoute(currentRoute);
            
            if (stepsLst.Count() == 0)
                throw new Exception("There is no soliutions");

            var maxValue = stepsLst.Max(x => x.Sum(y => y.Value));
            var results = stepsLst.Where(x => x.Sum(y => y.Value) == maxValue).ToArray();

            var stepsRoutes = new StepsRoutes()
            {
                Sum = maxValue,
                StepsGroups = new List<List<Step>>()
            };
            stepsRoutes.StepsGroups = results.ToList();

            return stepsRoutes;
        }
        
        private void FindRoute(List<Step> currentRoute)
        {
            try
            {
                do
                {
                    if (currentRoute.Count() == lst.Count())
                    {
                        stepsLst.Add(currentRoute);
                        return;
                    }

                    //children
                    var vLeft = lst[currentRoute.Last().StepLine + 1][currentRoute.Last().StepCol];
                    var vRight = lst[currentRoute.Last().StepLine + 1][currentRoute.Last().StepCol + 1];

                    //children check
                    bool availableLeft = false;
                    bool availableRight = false;
                    if ((currentRoute.Last().Value % 2 == 0 && vLeft % 2 != 0) || (currentRoute.Last().Value % 2 != 0 && vLeft % 2 == 0))
                        availableLeft = true;
                    if ((currentRoute.Last().Value % 2 == 0 && vRight % 2 != 0) || (currentRoute.Last().Value % 2 != 0 && vRight % 2 == 0))
                        availableRight = true;

                    if (availableLeft && availableRight)
                    {
                        var newBranch = new List<Step>(currentRoute);
                        newBranch.Add(
                            new Step()
                            {
                                Value = vRight,
                                StepLine = newBranch.Last().StepLine + 1,
                                StepCol = newBranch.Last().StepCol + 1
                            });
                        FindRoute(newBranch);

                        currentRoute.Add(
                            new Step()
                            {
                                Value = vLeft,
                                StepLine = currentRoute.Last().StepLine + 1,
                                StepCol = currentRoute.Last().StepCol
                            });
                    }
                    else if (availableLeft)
                    {
                        currentRoute.Add(
                            new Step()
                            {
                                Value = vLeft,
                                StepLine = currentRoute.Last().StepLine + 1,
                                StepCol = currentRoute.Last().StepCol
                            });
                    }
                    else if (availableRight)
                    {
                        currentRoute.Add(
                            new Step()
                            {
                                Value = vRight,
                                StepLine = currentRoute.Last().StepLine + 1,
                                StepCol = currentRoute.Last().StepCol + 1
                            });
                    }
                    else
                    {
                        return;
                    }

                    if (currentRoute.Count() == lst.Count())
                    {
                        stepsLst.Add(currentRoute);
                        return;
                    }
                }
                while (currentRoute.Count() != lst.Count());
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }

    public class Step
    {
        public int Value { get; set; }

        public int StepLine { get; set; }

        public int StepCol { get; set; }

    }

    public class StepsRoutes
    {
        public int Sum { get; set; }

        public List<List<Step>> StepsGroups { get; set; }
    }

}
