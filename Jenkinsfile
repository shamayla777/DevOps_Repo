pipeline {
    agent any
	triggers {
        cron('H/15 * * * *')
    }
    stages {
		stage('Checkout') {
            steps {
                checkout scm
            }
        }
		stage('Build') {
            steps {
				bat 'iisreset /stop'
				bat "${tool 'MsBuild'} ${'"C:/Program Files (x86)/Jenkins/workspace/DevOps_Training/Employee_webservice/Employee_webservice.sln"'} ${'/p:Configuration=Release'}" 
				bat "${tool 'MsBuild'} ${'"C:/Program Files (x86)/Jenkins/workspace/DevOps_Training/SpecflowTest_Assignment3/Employee_wc_test02.sln"'} ${'/p:Configuration=Release'}" 
				bat 'iisreset /start'
            }
        }
		stage('RunTest') {
            steps {
                bat '"C:/Program Files (x86)/NUnit.org/nunit-console/nunit3-console.exe" "C:/Program Files (x86)/Jenkins/workspace/DevOps_Pipeline/DevOps_Automation/DevOps_Automation/bin/Release/DevOps_UnitTest.dll"'
            }
        }
		stage("PublishTestReport"){
			steps {
				nunit testResultsPattern: 'TestResult.xml'
			}	
		}
    }
}