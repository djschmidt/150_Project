
var newSkin: GUISkin;
var buttonSkin: GUISkin;
var logoTexture : Texture2D;
private var toolbarInt:int=0;
var toolbarString: String[]= ["Audio","Graphics"];
var start:GameObject;
private var savedTimeScale:float;
private var pauseFilter;
private var startTime = 0.1;
private var menu = false;
private var options = false;
var TheCamera : Transform;













function BeginPage(width,height) {

	GUILayout.BeginArea(Rect((Screen.width-width)/2,(Screen.height-height)/2,width,height));
}



function ShowBackButton(){

	if (GUI.Button(Rect(20,Screen.height-50,50,20),"Back")) {
	
	options=false;
	menu=false;
	UnPauseGame();
	
		
	}

}


function options_menu(){

BeginPage(300,300);
toolbarInt=GUILayout.Toolbar(toolbarInt,toolbarString);

	
	
	if(toolbarInt == 0)
	{
	
		GUILayout.Label("Volume");
		AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume,0.0,1.0);
		
	
	}
	
	
	

	else
	{
	
		GUILayout.Label(QualitySettings.names[QualitySettings.GetQualityLevel()]);
	
		GUILayout.BeginHorizontal();
	
		if(GUILayout.Button("Decrease"))
		{
	
			QualitySettings.DecreaseLevel();
		}
	
	
		if(GUILayout.Button("Increase"))
		{
			QualitySettings.IncreaseLevel();
	
		}
	
	GUILayout.EndHorizontal();

}

EndPage();


}

function LateUpdate() 

{

	
	
	if(Input.GetKeyDown(KeyCode.P) && !IsGamePaused())
	
	{
	
		PauseGame();
		menu=true;
			
	}
		
	if(Input.GetKeyDown(KeyCode.U) && options==false)
	{
	
	UnPauseGame();
	menu=false;
	
	}
	

	
	


}



function EndPage(){

	GUILayout.EndArea();
	ShowBackButton();
	

}


function FirstMenu() {

	//layout start
	GUI.BeginGroup(Rect(Screen.width / 2-150, 100, 300, 200));
	
	
	GUI.Box(Rect(0, 0, 300, 200), "");
	
	//logo picture
	GUI.Label(Rect(15,10,300,68), logoTexture);
	
	

	
	if(GUI.Button(Rect(55, 50, 180, 40),"Options"))
	{
		
		options =true;
		menu=false;
	}
	

	
	
	if(GUI.Button(Rect(55, 100, 180, 40), "Quit"))
	
	{
	
	Application.LoadLevel("gamestart");
	Screen.showCursor=true;
	audio.Play();
	

	}
	
	

	GUI.EndGroup();
	
	
	}
	



	
function IsBeginning(){

return Time.time < startTime;

}
	
	
function PauseGame(){



savedTimeScale = 1.0;
Time.timeScale = 0;
AudioListener.pause = true;
GetComponent("MouseLook").enabled=false;





}

function UnPauseGame()

{

	Time.timeScale=savedTimeScale;
	AudioListener.pause = false;

	if (pauseFilter){

		pauseFilter.enabled = false;

	}	

	if (IsBeginning() && start != null) {
		start.active = true;
	
	}

GetComponent("MouseLook").enabled=true;

}

function IsGamePaused(){



	if(Time.timeScale==0){

		return true;
	}

	else

	{

	return false;

	}
	
}


function OnGUI () {





	if(menu==true)
	{
	
	GUI.skin=newSkin;
	
	
	FirstMenu();
	
	}
		


	if(options==true)
	{
	
	GUI.skin = newSkin;
	options_menu();
	
	}
	

	
	
	}
	
