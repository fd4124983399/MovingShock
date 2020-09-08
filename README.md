# MovingShock

A simple demo of moving a object in Update() and FixedUpdate()

If you move a object which is attached with collider components in Update(), it will keep bumping into wall and be pushed back, causing a weird result.

The reason is that the object update it's position, i.e. keep moving, making it looks like bumping into the wall, and it may be rendered BEFORE the physics engine resolve collision.
That is, there may be NO physics engine update before rendering.

You should move it in FixedUpdate() so that the physics engine can always be able to resolve collision, keep the object stable.
Directly changes "transform.position" may work, but the better way is to use "Rigidbody.MovePosition()" if the object is attached with Rigidbody component.

# How to use this project

Open Scene.unity, and check the "ball" gameobject, there are 2 boolean variables on it's "ObjectMover" component.

![](https://i.imgur.com/BeWvQbE.png)

If you want to move the object in FixedUpdate(), set UseFixedUpdate to True, or it will be moved in Update().

If you want to move the object with MovePosition(), set UseMovePosition to True, or it will be moved with update it's transform.position directly.

Press "space bar" to reset the ball's position.

Have fun.
