using _Scripts._Helpers;

namespace Core.Game_Manager
{

    public abstract class GameManagerBase : Singleton<GameManagerBase>
    {

        public GameState CurrentState { get; }
        /* Main menu 
         *
         * Load Different saves
         *
         * click play
         *
         * set current player ID 
         *
         * load new scene
         *
         * initialize managers in new scene
         *
         * load from save
         *
         * 
         * 
         */

        protected virtual void SwitchState(GameState newState)
        {
            
        }
        
        
    }

}
