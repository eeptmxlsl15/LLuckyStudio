using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaitTask : CustomYieldInstruction
{
	Task task;

	public WaitTask(Task task)
	{
		this.task = task;
	}

	public override bool keepWaiting => !task.IsCompleted;
}
