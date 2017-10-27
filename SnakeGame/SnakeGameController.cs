using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace SnakeGame
{
    public class SnakeGameController : Controller
    {
        Timer timer;
        Timer memtime;
        bool pause=false;
        public SnakeGameController()
        {
            // update the board every one second;
            timer = new Timer(SnakeGameModel.TIME_BASE / SnakeGameModel.Speed);
            timer.Enabled = false;
            timer.Elapsed += this.OnTimedEvent;
        }


        public void KeyUpHandled(KeyboardState ks)
        {
            int direction = -1;
            Keys[] keys = ks.GetPressedKeys();
            if (keys.Contains(Keys.Space))
            {
              
                    
                    
                    Stop();
                    //System.Threading.Thread.Sleep(1000);
                    
                
                    
                    
            }
            else if (keys.Contains(Keys.Up))
            {
                Start();
                direction = SnakeGameModel.MOVE_UP;
            }
            else if(keys.Contains(Keys.Down))
            {
                Start();
                direction = SnakeGameModel.MOVE_DOWN;
            }
            else if(keys.Contains(Keys.Left))
            {
                Start();
                direction = SnakeGameModel.MOVE_LEFT;
            }
            else if(keys.Contains(Keys.Right))
            {
                Start();
                direction = SnakeGameModel.MOVE_RIGHT;
            }
            
            // Find all snakeboard model we know
          
            
            /*  if (direction == -5 && pause==false) {
               // memtime = timer;
                Stop();
                pause = true;
            }
           else if (direction == -5 && pause == true)
            {
               // timer = memtime;
                Start();
                pause = false;
            }*/
            if (direction == -1) return;
            foreach (Model m in mList)
            {
                if (m is SnakeGameModel)
                {
                    // Tell the model to update
                    SnakeGameModel sbm = (SnakeGameModel)m;
                    sbm.SetDirection(direction);
                }
            }

        }


        public void Start()
        {
            timer.Start();
            // timer.Enabled = true; 
        }

        public void Stop()
        {
            // Stop the game
            timer.Stop();
            //  timer.Enabled = false;
            //timer.Enabled = !timer.Enabled;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Snake.Debug("TE");
            foreach (Model m in mList)
            {
                if (m is SnakeGameModel)
                {
                    SnakeGameModel sbm = (SnakeGameModel)m;
                    sbm.Move();
                    sbm.Update();
                }
            }
            timer.Interval = SnakeGameModel.TIME_BASE / SnakeGameModel.Speed;
        }

    }
}
