using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class ProcedureMenu : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }
    }

}
