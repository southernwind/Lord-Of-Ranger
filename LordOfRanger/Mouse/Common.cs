﻿using System.Collections.Generic;

namespace LordOfRanger.Mouse {
	internal enum Operation {

		LEFT,
		RIGHT,
		MOVE

	}

	internal class MouseData {

		internal MouseData() {
			SwitchState = SwitchingStyle.BOTH;
			Value = new List<Set>();
		}

		internal SwitchingStyle SwitchState {
			get;
			set;
		}
		internal List<Set> Value {
			get;
			set;
		}

	}

	class Set {
		internal readonly Operation op;
		internal readonly int x;
		internal readonly int y;
		internal readonly int sleepBetween;
		internal readonly int sleepAfter;

		internal Set( Operation op, int x, int y, int sleepBetween, int sleepAfter ) {
			this.op = op;
			this.x = x;
			this.y = y;
			this.sleepBetween = sleepBetween;
			this.sleepAfter = sleepAfter;
		}

	}
}
