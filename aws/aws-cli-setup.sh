aws ecr create-repository --repository-name events-eng --image-scanning-configuration scanOnPush=true


aws elbv2 create-target-group \
     --name ecs-eng-events \
     --protocol HTTP \
     --port 80 \
     --target-type ip \
     --vpc-id vpc-2c6bd04b \
	 --health-check-path /events/swagger/index.html


#check first what priority you will use in the next command
aws elbv2 describe-rules --listener-arn arn:aws:elasticloadbalancing:ap-southeast-1:711157212011:listener/app/ENG-ALB/d9254fc2d6a42763/e91b05f110f18290

#delete rule priority 4 if exist config
aws elbv2 delete-rule \
--rule-arn arn:aws:elasticloadbalancing:ap-southeast-1:711157212011:listener-rule/app/ENG-ALB/d9254fc2d6a42763/e91b05f110f18290/d3f8cdc47

aws elbv2 create-rule \
--listener-arn arn:aws:elasticloadbalancing:ap-southeast-1:711157212011:listener/app/ENG-ALB/d9254fc2d6a42763/e91b05f110f18290 \
--priority 2 \
--conditions file://aws-elb-create-listener-rule.json \
--actions Type=forward,TargetGroupArn=arn:aws:elasticloadbalancing:ap-southeast-1:711157212011:targetgroup/ecs-eng-events/0771e165b29db09f


#create service
aws ecs create-service --cli-input-json file://aws-ecs-create-service.json  --region ap-southeast-1

#run the pipeline


aws elbv2 describe-target-groups \
    --target-group-arns arn:aws:elasticloadbalancing:ap-southeast-1:711157212011:targetgroup/ecs-events-service/7ae5e88d688ce983