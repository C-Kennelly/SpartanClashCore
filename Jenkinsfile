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
            slackSend (color: '#FFFF00', message: "Starting ${env.JOB_NAME} [${env.BUILD_NUMBER}]. View status at (${env.BUILD_URL})")
            sh 'docker build -t ${containerNameSpace}/${containerName}:${env.BUILD_NUMBER} ${dockerBuildFolder}'
            sh 'docker push ${containerNameSpace}/${containerName}:${env.BUILD_NUMBER}'
          }
    }
    stage('Deploy') {
      parallel {
        stage('Pull New') {
          steps {
            //slackSend(message: "'${applicationDisplayName}' began deployment.", color: 'good')
            sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker pull ${containerNameSpace}/${containerName}:${env.BUILD_NUMBER}'
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
        //slackSend(message: "'${applicationDisplayName}' is starting...", color: 'good')
        sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker run -d -p  80:80 --name ${applicationName} ${containerNameSpace}/${containerName}:${env.BUILD_NUMBER}'
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
//        slackSend(message: "'${applicationDisplayName}' is live at http://138.197.202.218", color: 'good')
//      }
//      failure {
//        slackSend(message: "'${applicationDisplayName}' failed while starting!", color: 'danger')
//      }
//    }

