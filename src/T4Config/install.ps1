param($installPath, $toolsPath, $package, $project)

$project.ProjectItems.Item("Configurations.tt").Properties.Item("BuildAction").Value = 0 #prjBuildActionNone