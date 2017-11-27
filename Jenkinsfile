pipeline {
  agent any
  stages {
    stage('Build & Push') {
      parallel {
        stage('Slack Notification') {
          steps {
            slackSend(message: 'Spartan Clash began building', color: 'good')
          }
        }
        stage('Build & Push') {
          steps {
            sh 'docker build -t ckennelly/spartanclash:${BUILD_NUMBER} SpartanClash'
            sh 'docker push ckennelly/spartanclash:${BUILD_NUMBER}'
          }
        }

      }
    }
    stage('Pull New') {
      parallel {
        stage('Slack Notification') {
          steps {
            slackSend(message: 'Spartan Clash began deployment.', color: 'good')
          }
        }
        stage('Pull New') {
          steps {
            sh 'ssh jenkinssvc@138.197.202.218 docker pull ckennelly/spartanclash:${BUILD_NUMBER}'            
          }
        }
        stage('Stop Old') {
          steps {
            sh 'ssh jenkinssvc@138.197.202.218 docker stop SpartanClash'
            sh 'ssh jenkinssvc@138.197.202.218 docker rm SpartanClash'
          }
        }
      }
    }
    stage('Run New') {
      parallel {
        stage('Slack Notification') {
          steps {
            slackSend(message: 'Spartan Clash is starting...', color: 'good')
          }
        }
        stage('Run New') {
          steps {
            sh 'ssh jenkinssvc@138.197.202.218 docker run -d -p  80:80 --name SpartanClash ckennelly/spartanclash:${BUILD_NUMBER}'       
          }
        }
      }
    }
    stage('Notify Success') {
      steps {
        slackSend(message: 'Spartan Clash is live at http://138.197.202.218', color: 'good')
      }
    }
  }
}
