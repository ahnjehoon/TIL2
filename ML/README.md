# 용어정리

- 에포크(epoch)
  학습데이터 전체를 한바퀴 도는 것
- 배치 정규화(Batch Normalization)
  과적합을 막아주는 기법
  학습 속도도 향상시켜 주는 장점이 있음
  원래 과적합 문제보다 학습 시 발산이나 소실 등을 방지하여 학습 속도를 높이기 위해 발명된 기법
  텐서플로에서는 tf.nn.batch_normalization과 tf.layers.batch_normalization함수로 쉽게 적용 가능
  고수준 API인 tf.layers 사용시 tf.layers.batch_normalization(L1, training=is_training)

