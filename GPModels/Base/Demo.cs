using System;
using System.Collections.Generic;
using System.Text;

namespace GPModels.Base
{
    public class Demo
    {
        public Type[] GetMenus()
        {
            return  new Type[]
                {
                    new Type
                    {
                        cateid ="1",
                        catename="冷菜",
                        catestate =1,
                        dishes = new Dish[]
                        {
                            new Dish
                            {
                                gdsname="花生米",
                                gdsprice="0.01",
                                gdsid="1001"
                            },
                        new Dish
                            {
                                gdsname="凉拌木耳",
                                gdsprice="0.01",
                                gdsid="1002"
                            }
                        }
                    },
                    new Type
                    {
                        cateid ="2",
                        catestate=1,
                        catename ="热菜"
                    }
            };
 
        }

    }
}
