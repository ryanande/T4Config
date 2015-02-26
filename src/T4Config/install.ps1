param($installPath, $toolsPath, $package, $project)

$project.ProjectItems.Item("T4Config.tt").Properties.Item("BuildAction").Value = 0 #prjBuildActionNone