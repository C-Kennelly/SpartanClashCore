pipeline {
  agent any
  stages {
    stage('Build') {
      parallel {
        stage('Build') {
          steps {
            sh 'dotnet build'
          }
        }
        stage('') {
          steps {
            slackSend 'Pipeline Build Started!'
          }
        }
      }
    }
    stage('Notify') {
      steps {
        slackSend 'Pipeline Build Complete!'
      }
    }
  }
}