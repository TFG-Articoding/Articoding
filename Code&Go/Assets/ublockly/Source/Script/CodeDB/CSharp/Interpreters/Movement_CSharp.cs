﻿/****************************************************************************

Functions for interpreting c# code for blocks.

Copyright 2016 sophieml1989@gmail.com

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

****************************************************************************/


using System;
using System.Collections;
using UnityEngine;

namespace UBlockly
{
    public class Times
    {
        public static float instructionWaitTime = 1.5f;   
        public static float logicWaitTime = 0.3f;   
    }
    
    [CodeInterpreter(BlockType = "movement_move_laser")]
    public class Move_Laser_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            CmdEnumerator ctor = CheckInput.TryValueReturn(block, "AMOUNT", new DataStruct(0), "Missing_Value_Movement_Laser");

            yield return ctor;
            DataStruct arg0 = ctor.Data;

            string dir = block.GetFieldValue("DIRECTION");

            string msg = arg0 + " " + dir;
            MessageManager.Instance.SendMessage(msg, MSG_TYPE.MOVE_LASER);

            yield return new WaitForSeconds(Times.instructionWaitTime);
        }
    }

    [CodeInterpreter(BlockType = "movement_move")]
    public class Move_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            CmdEnumerator ctor = CheckInput.TryValueReturn(block, "NAME", new DataStruct(0), "Missing_Value_Object_Name");
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            ctor = CheckInput.TryValueReturn(block, "AMOUNT", new DataStruct(0), "Missing_Value_Movement_Object");
            yield return ctor;
            DataStruct arg1 = ctor.Data;

            string dir = block.GetFieldValue("DIRECTION");

            string msg = arg0 +" "+ arg1 + " " + dir;
            MessageManager.Instance.SendMessage(msg, MSG_TYPE.MOVE);

            yield return new WaitForSeconds(Times.instructionWaitTime);
        }
    }

    [CodeInterpreter(BlockType = "movement_rotate_laser")]
    public class Rotate_Laser_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            CmdEnumerator ctor = CheckInput.TryValueReturn(block, "AMOUNT", new DataStruct(0), "Missing_Value_Rotation_Laser");
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            string rot = block.GetFieldValue("ROTATION");

            string msg = arg0 + " " + rot;
            MessageManager.Instance.SendMessage(msg, MSG_TYPE.ROTATE_LASER);

            yield return new WaitForSeconds(Times.instructionWaitTime);
        }
    }

    [CodeInterpreter(BlockType = "movement_rotate")]
    public class Rotate_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            CmdEnumerator ctor = CheckInput.TryValueReturn(block, "NAME", new DataStruct(0), "Missing_Value_Object_Name");
            
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            ctor = CheckInput.TryValueReturn(block, "AMOUNT", new DataStruct(0), "Missing_Value_Rotation_Object");
            
            yield return ctor;
            DataStruct arg1 = ctor.Data;

            string rot = block.GetFieldValue("ROTATION");

            string msg = arg0 + " " + arg1 + " " + rot;
            MessageManager.Instance.SendMessage(msg, MSG_TYPE.ROTATE);

            yield return new WaitForSeconds(Times.instructionWaitTime);
        }
    }

    [CodeInterpreter(BlockType = "movement_laser_change_intensity")]
    public class Change_Intensity_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            CmdEnumerator ctor = CheckInput.TryValueReturn(block, "AMOUNT", new DataStruct(0), "Missing_Value_Laser_Intensity");
            yield return ctor;
            DataStruct arg0 = ctor.Data;
            Number amount = arg0.NumberValue;           

            string msg = "1 " + amount;
            MessageManager.Instance.SendMessage(msg, MSG_TYPE.CHANGE_INTENSITY);

            yield return new WaitForSeconds(Times.instructionWaitTime);
        }
    }

    [CodeInterpreter(BlockType = "movement_activate_door")]
    public class Activate_Door_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            CmdEnumerator ctor = CheckInput.TryValueReturn(block, "ACTIVE", new DataStruct(0), "Missing_Value_Door_Active");
            yield return ctor;
            DataStruct arg0 = ctor.Data;

            ctor = CheckInput.TryValueReturn(block, "NAME", new DataStruct(0), "Missing_Value_Object_Name");
            yield return ctor;
            DataStruct arg1 = ctor.Data;

            string msg = arg1 + " " + arg0;
            MessageManager.Instance.SendMessage(msg, MSG_TYPE.ACTIVATE_DOOR);

            yield return new WaitForSeconds(Times.instructionWaitTime);
        }
    }
}
