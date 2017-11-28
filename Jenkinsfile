pipeline {  
  agent any

  environment {
    applicationName = 'SpartanClash'
    applicatonDisplayName = 'Spartan Clash'

    containerNameSpace = 'ckennelly'
    containerName = 'spartanclash'
    dockerBuildFolder = 'SpartanClash'
    
    jenkinsServiceAccount = 'jenkinssvc'
    acceptanceServerIP = '138.197.202.218'
  }

  stages {
    stage('Build & Push') {
          steps {
            slackSend (color: '#FFFF00', message: "Starting build for '${env.JOB_NAME} [${env.BUILD_NUMBER}'']. View status at (${env.BUILD_URL})")
            sh 'docker build -t ${containerNameSpace}/${containerName}:${BUILD_NUMBER} ${dockerBuildFolder}'
            sh 'docker push ${containerNameSpace}/${containerName}:${BUILD_NUMBER}'
          }
    }
    stage('Deploy') {
      parallel {
        stage('Pull New') {
          steps {
            slackSend (color: '#FFFF00', message: "${env.JOB_NAME} [${env.BUILD_NUMBER}] began deployment.  ")
            sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker pull ${containerNameSpace}/${containerName}:${BUILD_NUMBER}'
          }
        }
        stage('Clean Old') {
          steps {
            sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker stop ${applicationName}'
            sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker rm ${applicationName}'
            //sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker rm $(docker ps -a -q -f status=exited)'
          }
        }
      }
    }

    stage('Start Application') {
      steps {
        slackSend (color: '#FFFF00', message: "Starting ${env.JOB_NAME} [${env.BUILD_NUMBER}]...")
        sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker run -d -p  80:80 --name ${applicationName} ${containerNameSpace}/${containerName}:${BUILD_NUMBER}'
      }
      post {
        success {
          slackSend(message: "Spartan CLash is live at http://138.197.202.218", color: 'good')
        }
      }
    }
  }
}

//    post {
//      failure {
//        slackSend(message: "'${applicationDisplayName}'' failed during build!", color: 'danger')
//      }
//    }

//    post {
//      failure {
//        slackSend(message: "'${applicationDisplayName}' failed during deployment!", color: 'danger')
//      }
//    }
    
//    post {
//      success {
//        
//      }
//      failure {
//        slackSend(message: "'${applicationDisplayName}' failed while starting!", color: 'danger')
//      }
//    }

