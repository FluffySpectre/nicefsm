using NiceFSM.Messaging;

namespace NiceFSM 
{
	public class StateMachine<T> where T : class {
		State<T> mPreviousState;
		State<T> mCurrentState;
		State<T> mGlobalState;
	
		// Reference to the Owner of the statemachine
		T mOwner;
	
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="owner">Owner.</param>
		public StateMachine(T owner) {
		    mOwner = owner;
		}
	
		/// <summary>
		/// Changes the state
		/// </summary>
		/// <param name="newState">New state.</param>
		/// <param name="runNewState">If set to <c>true</c> run new state.</param>
		public void ChangeState(State<T> newState) {
		    if (mCurrentState != null)
		    	mCurrentState.Exit(mOwner);
	
		    mPreviousState = mCurrentState;
		    mCurrentState = newState;
		    mCurrentState.Enter(mOwner);
		}
	
		/// <summary>
		/// Changes global state
		/// </summary>
		/// <param name="newState">New state.</param>
		/// <param name="runNewGlobalState">If set to <c>true</c> run new global state.</param>
		public void ChangeGlobalState(State<T> newState) {
		    if (mGlobalState != null)
		        mGlobalState.Exit(mOwner);
	
		    mGlobalState = newState;
		    mGlobalState.Enter(mOwner);
		}
	
		/// <summary>
		/// Reverts to the previous State
		/// </summary>
		public void RevertToPreviousState() {
			if (mPreviousState != null)
				ChangeState(mPreviousState);
		}
	
		/// <summary>
		/// Runs current and global state
		/// </summary>
		public void Update() {
		    if (mCurrentState != null)
		    	mCurrentState.Execute(mOwner);
	
		    if (mGlobalState != null)
		        mGlobalState.Execute(mOwner);
		}
	
		/// <summary>
		/// Forwards the message to the global and current state
		/// </summary>
		/// <returns><c>true</c>, if message was handled, <c>false</c> otherwise.</returns>
		/// <param name="message">Message.</param>
		public bool HandleMessage(Telegram message) {
		    // Check if the state can handle this message
		    if (mCurrentState != null && mCurrentState.OnMessage(mOwner, message))
		        return true;
	
			// Check if the global state can handle this message
		    if (mGlobalState != null && mGlobalState.OnMessage(mOwner, message))
		        return true;
	
		    return false;
		}
	}
}
