using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using XPadderal;

namespace XPadderal
{
    public class ControllerEngine
    {
        private bool input_disabled = false;
        Timer timer_disableInput;

        private string currentProfileName = "%profile%";

        private DispatcherTimer clock;
        private GamePadState oldgstate;
        private JoystickState oldjstate;

        private List<OpenTK.Input.ButtonState> GamePadButtons;
        private List<OpenTK.Input.ButtonState> JoystickButtons;

        // Event Declaration
        // GamePadAction: Triggered when the oldgstate is different from the current GamePadState
        // JoystickAction: Triggered when the oldjstate is different from the current JoystickState


        private int clockspeed = 25; // 25 millisecond window for clock on joystick polling.

        public ControllerEngine()
        {
            this.ActiveDevice = 0;
            this.GamePadButtons = new List<OpenTK.Input.ButtonState>();
            this.JoystickButtons = new List<OpenTK.Input.ButtonState>();
            oldgstate = GamePad.GetState(this.ActiveDevice);

            oldjstate = Joystick.GetState(this.ActiveDevice);
            createNewTimer();
        }

        private void createNewTimer()
        {
            clock = new DispatcherTimer();
            clock.Tick += new EventHandler(checkGamePads);
            clock.Interval = new TimeSpan(0, 0, 0, 0, this.clockspeed);
            clock.Start();

            timer_disableInput = new Timer();
            timer_disableInput.Tick += new EventHandler(enableInput);
            timer_disableInput.Interval = 250;
            timer_disableInput.Enabled = true;
            timer_disableInput.Stop();
        }

        private void enableInput(Object sender, EventArgs e)
        {
            timer_disableInput.Stop();
            input_disabled = false;
        }

        public int ActiveDevice { get; set; }

        public GamePadCapabilities CapabilitiesGamePad { get { return GamePad.GetCapabilities(this.ActiveDevice); } }

        public JoystickCapabilities CapabilitiesJoystick { get { return Joystick.GetCapabilities(this.ActiveDevice); } }

        protected virtual void OnGamePadAction(ActionEventArgs e)
        {
            EventHandler<ActionEventArgs> handler = GamePadAction;
            if (handler != null)
            {
                handler(this, e);
            } else
            {
                // custom hack
                var x = e.GamePadState.Buttons.Back == OpenTK.Input.ButtonState.Pressed;
                if (x && !input_disabled)
                {
                    // lock input for 250ms
                    timer_disableInput.Start();

                    // pressed [select] button
                    ProfileOverlayForm ProfileOverlay = new ProfileOverlayForm();
                    if (this.currentProfileName == "%profile%")
                    {
                        this.currentProfileName = getInitialProfileName();  // read from ini (first time)
                    }
                    else if (this.currentProfileName == "Youtube")
                    {
                        this.currentProfileName = "VLC";
                    }
                    else
                    {
                        this.currentProfileName = "Youtube";
                    }
                    ProfileOverlay.profileName = this.currentProfileName;
                    ProfileOverlay.Show();
                }
            }
        }

        private string getInitialProfileName()
        {
            List<string> names = new List<string>();
            names.Add("VLC");
            names.Add("Youtube");

            // read current profile index from ini
            var data = File
            .ReadAllLines("C:\\Program Files (x86)\\xpadder\\Xpadder.ini")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            if (data["AutoProfile1Activated"] == "1")
            {
                return names[0];
            }
            if (data["AutoProfile2Activated"] == "1")
            {
                return names[1];
            }

            return "?";
        }

        protected virtual void OnJoystickAction(ActionEventArgs e)
        {
            EventHandler<ActionEventArgs> handler = JoystickAction;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void getButtonStates()
        {
            ActionEventArgs args = new ActionEventArgs(this.ActiveDevice);
            int buttonCount = this.CapabilitiesJoystick.ButtonCount;

            var joystick = Joystick.GetState(this.ActiveDevice);

            /*if (oldjstate.GetButton(JoystickButtons.Button0) != joystick.GetButton(JoystickButtons.Button0))
            {
                if (joystick.GetButton(JoystickButtons.Button0) == ButtonState.Pressed)
                {
                    OnButton0Pressed(args);
                }
                else if (joystick.GetButton(JoystickButtons.Button0).Equals(ButtonState.Released))
                {
                    OnButton0Released(args);
                }
            }
            if (oldjstate.GetButton(JoystickButtons.Button1) != joystick.GetButton(JoystickButtons.Button1))
            {
                if (joystick.GetButton(JoystickButtons.Button1).Equals(ButtonState.Pressed))
                {
                    OnButton1Pressed(args);
                }
                else if (joystick.GetButton(JoystickButtons.Button1).Equals(ButtonState.Released))
                {
                    OnButton1Released(args);
                }
            }*/

        }

        private void OnButton0Pressed(ActionEventArgs e)
        {
            EventHandler<ActionEventArgs> handler = Button0Pressed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnButton0Released(ActionEventArgs e)
        {
            EventHandler<ActionEventArgs> handler = Button0Released;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnButton1Pressed(ActionEventArgs e)
        {
            EventHandler<ActionEventArgs> handler = Button1Pressed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnButton1Released(ActionEventArgs e)
        {
            EventHandler<ActionEventArgs> handler = Button1Released;
            if (handler != null)
            {
                handler(this, e);
            }
        }



        private void checkGamePads(Object sender, EventArgs e)
        {
            ActionEventArgs args = new ActionEventArgs(this.ActiveDevice);
            if (!args.GamePadState.Equals(oldgstate))
            {
                //call event
                OnGamePadAction(args);

                oldgstate = args.GamePadState;
            }
            if (!args.JoystickState.Equals(oldjstate))
            {
                //call event
                getButtonStates();
                OnJoystickAction(args);
                oldjstate = args.JoystickState;
            }
        }

        public event EventHandler<ActionEventArgs> GamePadAction;

        public event EventHandler<ActionEventArgs> JoystickAction;

        public event EventHandler<ActionEventArgs> Button0Pressed;

        public event EventHandler<ActionEventArgs> Button0Released;

        public event EventHandler<ActionEventArgs> Button1Pressed;

        public event EventHandler<ActionEventArgs> Button1Released;


    }

    public class ActionEventArgs : EventArgs
    {
        public ActionEventArgs()
        {
            this.Instance = 0;
        }

        public ActionEventArgs(int ControllerInstance)
        {
            this.Instance = ControllerInstance;
        }

        public int Instance { get; set; }

        public GamePadState GamePadState { get { return GamePad.GetState(this.Instance); } }

        public JoystickState JoystickState { get { return Joystick.GetState(this.Instance); } }
    }
}