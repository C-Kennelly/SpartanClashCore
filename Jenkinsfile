pipeline {
  def applicationName = 'SpartanClash'
  def applicatonDisplayName = 'Spartan Clash'
  
  def containerNameSpace = 'ckennelly'
  def containerName = 'spartanclash'
  def dockerBuildFolder = 'SpartanClash'

  def jenkinsServiceAccount = 'jenkinssvc'
  def acceptanceServerIP = '138.197.202.218'
  
  agent any
  
  stages {
    stage('Build & Push') {
          steps {
            slackSend(message: '${applicationDisplayName} began building', color: 'good')
            sh 'docker build -t ${containerNameSpace}/${containerName}:${BUILD_NUMBER} ${dockerBuildFolder}'
            sh 'docker push ${containerNameSpace}/${containerName}:${BUILD_NUMBER}'
          }
    }
    post {
      failure {
        slackSend(message: '${applicationDisplayName} failed during build!', color: 'danger')
      }
    }

    stage('Deploy') {
      parallel {
        stage('Pull New') {
          steps {
            slackSend(message: '${applicationDisplayName} began deployment.', color: 'good')
            sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker pull ${containerNameSpace}/${containerName}:${BUILD_NUMBER}'
          }
        }
        stage('Clean Old') {
          steps {
            sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker stop ${applicationName}'
            sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker rm ${applicationName}'
            sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker rm $(docker ps -a -q -f status=exited)'
          }
        }
      }
    }
    post {
      failure {
        slackSend(message: '${applicationDisplayName} failed during deployment!', color: 'danger')
      }
    }

    stage('Start Application') {
      steps {
        slackSend(message: '${applicationDisplayName} is starting...', color: 'good')
        sh 'ssh ${jenkinsServiceAccount}@${acceptanceServerIP} docker run -d -p  80:80 --name ${applicationName} ${containerNameSpace}/${containerName}:${BUILD_NUMBER}'
      }
    }
    post {
      success {
        slackSend(message: '${applicationDisplayName} is live at http://138.197.202.218', color: 'good')
      }
      failure {
        slackSend(message: '${applicationDisplayName} failed while starting!', color: 'danger')
      }
    }
  }
}