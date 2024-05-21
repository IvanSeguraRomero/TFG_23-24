<template>
    <div class="comments">
      <h2>Comments</h2>
      <hr />
      <div class="comment">
        <div class="comment-left">
          <div class="user-info">
            <strong class="username">Username</strong>
            <span class="date">DATE PUBLISHED</span>
          </div>
          <div class="comment-actions">
            <span class="like-count">Likes: 30</span>
            <button class="like">LIKE</button>
          </div>
        </div>
        <div class="comment-right">
          <p>
            Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.
          </p>
        </div>
      </div>
      <div class="add-comment-container">
        <button class="add-comment">ADD COMMENT</button>
      </div>
    </div>
  </template>
  
  <style scoped>
  .comments {
    margin: 20px 0;
  }
  
  hr {
    width: 100%;
    border-color: #000;
    margin-top: 10px;
    margin-bottom: 10px;
  }
  
  .comment {
    display: flex;
    padding: 10px 0;
    margin-top: 10px;
    background-color: var(--color-blue);
  }
  
  .comment-left {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    width: 66.66%; /* Dos tercios del ancho */
    margin-right: 20px;
    margin-left: 10px;
  }
  
  .user-info {
    font-size: 0.9em;
  }
  
  .username {
    font-size: 1.2em;
    font-family: var(--font-archivo-black);
  }
  
  .date {
    font-family: var(--font-orbitron);
  }
  
  .user-info strong {
    display: block;
  }
  
  .comment-actions {
    display: flex;
    justify-content: space-between;
    align-items: center;
    text-align: justify;
  }
  
  .comment-right {
    width: 33.33%; /* Un tercio del ancho */
    font-family: var(--font-roboto);
    line-height: 1.4;
    text-align: justify;
    background-color: var(--color-dark-blue);
    margin-right: 10px;
  }
  
  .comment-right p {
    margin: 5px;
    color: var(--neutral-colors-white);
  }

  .like-count{
    font-family: var(--font-roboto);
  }
  
  .add-comment-container {
    display: flex;
    justify-content: flex-end;
    margin-top: 10px;
  }
  
  .add-comment, .like {
    font-family: var(--font-orbitron);
    color: var(--color-black);
    background-color: var(--color-yellow);
    padding: 10px;
    padding-inline: 20px;
  }
  </style>
  